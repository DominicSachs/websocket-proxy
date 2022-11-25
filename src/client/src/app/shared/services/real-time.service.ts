
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class RealTimeDataService {
  private informationSubject$ = new Subject<string>();
  readonly information$ = this.informationSubject$.asObservable();

  init(): void {
    console.log('connection: ', environment.hubUrl)
    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Debug)
      .withUrl(environment.hubUrl)
      .withAutomaticReconnect()
      .build();

    connection.start();

    connection.on('SendInformation', (message: string) => this.informationSubject$.next(message));
  }
}
