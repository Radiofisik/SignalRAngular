import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'signalrclient';
  ngOnInit(): void {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44369/message')
      .build();

    connection.on('send', data => {
      console.log(data);
    });

    connection.start()
      .then(() => connection.invoke('send', 'hi'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }
}
