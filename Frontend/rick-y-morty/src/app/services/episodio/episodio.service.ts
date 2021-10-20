import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConsultasService } from '../consultas.service';

@Injectable({
  providedIn: 'root',
})
export class EpisodioService {
  private readonly controlador = '/Episodio/';
  constructor(private consultaService: ConsultasService) {}

  public obtenerTodosLosEpisodios(): Promise<
}
