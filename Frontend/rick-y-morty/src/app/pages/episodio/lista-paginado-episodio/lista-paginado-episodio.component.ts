import { Component, OnInit } from '@angular/core';
import { SpinnerVisibilityService } from 'ng-http-loader';
import { Episodio } from 'src/app/models/episodio.model';
import { Personaje } from 'src/app/models/personaje.model';
import { TodosLosEpisodiosRespuesta } from 'src/app/models/respuestas/todos-los-episodios-respuesta';
import { EpisodioService } from 'src/app/services/episodio/episodio.service';
import { NotificacionesService } from 'src/app/services/notificaciones.service';
import { PersonajeService } from 'src/app/services/personaje/personaje.service';

@Component({
  selector: 'app-lista-paginado-episodio',
  templateUrl: './lista-paginado-episodio.component.html',
  styleUrls: ['./lista-paginado-episodio.component.css'],
})
export class ListaPaginadoEpisodioComponent implements OnInit {
  private episodiosPaginado: TodosLosEpisodiosRespuesta;
  public episodios: Array<Episodio>;
  public episodio: Episodio;
  public paginaActual: number = 1;

  public personajes: Array<Personaje>;
  public personaje: Personaje;

  constructor(
    private episodioService: EpisodioService,
    private notificacionesService: NotificacionesService,
    private spinner: SpinnerVisibilityService,
    private personajeService: PersonajeService
  ) {
    this.episodiosPaginado = new TodosLosEpisodiosRespuesta();
    this.episodios = new Array<Episodio>();
    this.episodio = new Episodio();
    this.personajes = new Array<Personaje>();
    this.personaje = new Personaje();
  }

  ngOnInit(): void {
    this.spinner.show();
    this.obtenerEpisodiosPaginados(this.paginaActual);
  }

  obtenerEpisodiosPaginados(pagina: number): void {
    this.spinner.show();
    this.personajes = new Array<Personaje>();
    this.personaje = new Personaje();
    this.episodio = new Episodio();
    this.episodioService
      .obtenerEpisodiosPaginados(pagina)
      .then((respuesta: TodosLosEpisodiosRespuesta) => {
        this.episodiosPaginado = respuesta;
        this.episodios = this.episodiosPaginado.results;
        this.spinner.hide();
      })
      .catch((e) => {
        this.notificacionesService.mostrarMensaje(
          'error',
          'Error',
          'Ha ocurrido un error al obtener los episodios'
        );
        this.spinner.hide();
      });
  }

  obtenerEpisodioPorId(id: number): void {
    this.spinner.show();
    this.episodioService
      .obtenerEpisodioPorId(id)
      .then((episodio: Episodio) => {
        this.episodio = episodio;
        const idsPersonaje = new Array<number>();
        this.episodio.characters.forEach((x) => {
          idsPersonaje.push(Number(x.substring(x.lastIndexOf('/') + 1)));
        });
        this.obtenerMultiplesPersonajesPorId(idsPersonaje);
        this.spinner.hide();
      })
      .catch((e) => {
        this.notificacionesService.mostrarMensaje(
          'error',
          'Error',
          'Ha ocurrido un error al obtener episodio seleccionado'
        );
        this.spinner.hide();
      });
  }

  obtenerMultiplesPersonajesPorId(ids: Array<number>): void {
    this.personajeService
      .obtenerMultiplesPersonajes(ids)
      .then((characters: Array<Personaje>) => {
        this.personajes = characters;
      })
      .catch((e) => {
        this.notificacionesService.mostrarMensaje(
          'error',
          'Error',
          'Ha ocurrido un error al obtener personajes'
        );
        this.spinner.hide();
      });
  }

  obtenerPersonajePorId(id: number): void {
    this.personajeService
      .obtenerPersonajePorId(id)
      .then((character: Personaje) => {
        this.personaje = character;
      })
      .catch((e) => {
        this.notificacionesService.mostrarMensaje(
          'error',
          'Error',
          'Ha ocurrido un error al obtener personaje'
        );
        this.spinner.hide();
      });
  }
}
