import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { mascota } from 'src/app/interfaces/mascota';
import { MascotaService } from 'src/app/services/mascota.service';

const listadoMascota: mascota[] = [];

@Component({
  selector: 'app-listado-mascota',
  templateUrl: './listado-mascota.component.html',
  styleUrls: ['./listado-mascota.component.css'],
})

export class ListadoMascotaComponent implements AfterViewInit {
  displayedColumns: string[] = ['nombre', 'especie', 'iddueno', 'fechanacimiento', 'raza', 'acciones'];
  dataSource = new MatTableDataSource<mascota>(listadoMascota);
  loading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor
  (
    private _snackBar: MatSnackBar,
    private _mascotaService: MascotaService
  ) {}

  ngOnInit(): void {
    this.obtenerMascota();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if(this.dataSource.data.length > 0) {
      this.paginator._intl.itemsPerPageLabel = 'items por pagina'
    }
    
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  obtenerMascota(){
    this.loading = true;
    this._mascotaService.getMascotas().subscribe(data => {
      this.loading = false;
      this.dataSource.data = data;
    })
  }

  eliminarMascota(id: number){
    this.loading = true;
    this._mascotaService.deleteMascota(id).subscribe(() => {
          this.mesajeExito();
          this.loading = false;
          this.obtenerMascota();
        })
  }

  mesajeExito(){
    this._snackBar.open('La mascota fue eliminada con exito', '', {
      duration: 2000, 
      horizontalPosition:'right'
    });
  }
}
