import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { mascota } from 'src/app/interfaces/mascota';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MascotaService } from 'src/app/services/mascota.service';

@Component({
  selector: 'app-agregar-editar-mascota',
  templateUrl: './agregar-editar-mascota.component.html',
  styleUrls: ['./agregar-editar-mascota.component.css']
})
export class AgregarEditarMascotaComponent {
    loading: boolean = false;
    form: FormGroup;
    id: number;
    operacion: string = "Agregar";

    constructor(
      private fb: FormBuilder,
      private _mascotaService: MascotaService,
      private _snackBar: MatSnackBar,
      private router: Router,
      private aRouter: ActivatedRoute
      ){
        this.form = this.fb.group({
          nombre: ['', Validators.required],
          especie: ['', Validators.required],
          iddueno: ['', Validators.required],
          fechanacimiento: ['', Validators.required],
          raza: ['', Validators.required]
        });

        this.id = Number(this.aRouter.snapshot.paramMap.get('id'));
    }

    ngOnInit(): void {
      if(this.id != 0) {
        this.operacion = "Editar";
        this.obtenerMascota(this.id);
      }
    }

    obtenerMascota(id: number) {
      this.loading = true;
      this._mascotaService.getMascota(id).subscribe(data => {
        this.form.patchValue({
          nombre: data.nombre,
          especie: data.especie,
          iddueno: data.iddueno,
          fechanacimiento: data.fechanacimiento,
          raza: data.raza
        });
        
        this.loading = false;
      });
    }

    agregarEditarMascota () {
      const mascota: mascota = {
        nombre: this.form.value.nombre,
        especie: this.form.value.especie,
        iddueno: this.form.value.iddueno,
        fechanacimiento: this.form.value.fechanacimiento,
        raza: this.form.value.raza
      }

      if(this.id != 0){
        mascota.id = this.id;
        this.editarMascota(this.id, mascota);
      }else{
        this.agregarMascota(mascota);
      }
    }

    editarMascota(id: number, mascota: mascota){
      this.loading = true;
      this._mascotaService.updateMascota(id, mascota).subscribe(() => {
        this.loading = false;
        this.mesajeExito('actualizada');
        this.router.navigate(['/listMascotas']);
      });
    }

    // Envia los objetos al back-end
    agregarMascota(mascota: mascota){
      this._mascotaService.addMascota(mascota).subscribe(data => {
        this.mesajeExito('registrada');
        this.router.navigate(['/listMascotas']);
      });
    }

    mesajeExito(text: string){
      this._snackBar.open(`La mascota fue ${text} con exito`, '', {
        duration: 2000, 
        horizontalPosition:'right'
      });
    }
}
