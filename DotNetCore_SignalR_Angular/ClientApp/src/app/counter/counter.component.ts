import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HttpTransportType } from '@aspnet/signalr';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent implements OnInit {
  public currentCount = 0;
  public connection: HubConnection;

  constructor() {
    const builder = new HubConnectionBuilder();
    this.connection = builder.withUrl('https://localhost:44300/contador').build();
  }

  ngOnInit() {
    this.connection.start().then(() => {
      this.connection.invoke('GetContador');

      this.connection.on('getContador', (valor) => {
        this.currentCount = valor;
      });

      this.connection.on('broadcastContador', (valor) => {
        this.currentCount = valor;
      });
    });
  }

  public incrementCounter() {
    this.connection.invoke('SomaContador');
  }
}
