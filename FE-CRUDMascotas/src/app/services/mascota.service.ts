import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { mascota } from '../interfaces/mascota';

@Injectable({
  providedIn: 'root'
})
export class MascotaService {
  private myAppUrl: string = 'https://localhost:7266/';
  //private myAppUrl: string = environment.endpoint;
  private myApiUrl: string = 'api/Mascota/';

  constructor(private http: HttpClient) { }

  getMascotas(): Observable<mascota[]> {
    return this.http.get<mascota[]>(`${this.myAppUrl}${this.myApiUrl}`);
  } 

  getMascota(id: number): Observable<mascota> {
    return this.http.get<mascota>(`${this.myAppUrl}${this.myApiUrl}${id}`);
  }

  deleteMascota(id: number): Observable<void> {
    return this.http.delete<void>(`${this.myAppUrl}${this.myApiUrl}${id}`);
  }

  addMascota(mascota: mascota): Observable<mascota> {
    return this.http.post<mascota>(`${this.myAppUrl}${this.myApiUrl}`, mascota);
  }

  updateMascota(id: number, mascota: mascota): Observable<void> {
    return this.http.put<void>(`${this.myAppUrl}${this.myApiUrl}${id}`, mascota);
  }
}
