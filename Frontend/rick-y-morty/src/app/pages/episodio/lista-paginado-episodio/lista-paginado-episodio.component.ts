import { Component, OnInit } from '@angular/core';
import { EpisodioService } from 'src/app/services/episodio/episodio.service';

@Component({
  selector: 'app-lista-paginado-episodio',
  templateUrl: './lista-paginado-episodio.component.html',
  styleUrls: ['./lista-paginado-episodio.component.css'],
})
export class ListaPaginadoEpisodioComponent implements OnInit {
  constructor(private episodioService: EpisodioService) {}

  ngOnInit(): void {}
}
