import {Component, OnInit} from '@angular/core';
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
      console.log('send', data);
    });

    connection.on('method', data => {
      console.log('method', data);
    });

    const connect = (conn) => {
      connection.start()
        .then(() => connection.invoke('subscribe', 'groupName'))
        .catch(err => {
          console.log('Error while starting connection: ' + err);
          setTimeout(() => connect(conn), 5000);
        });
    };

    connect(connection);
    connection.onclose((e) => connect(connection));
  }
}
