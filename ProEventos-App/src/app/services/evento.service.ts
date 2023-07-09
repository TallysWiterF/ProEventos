import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class EventoService {

  baseURL: string = 'https://localhost:7072/api/eventos';

  constructor(private http: HttpClient) { }

  public getEventos() {
    return this.http.get(this.baseURL);
  }
}
