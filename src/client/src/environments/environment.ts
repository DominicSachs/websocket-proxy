import * as signalR from '@microsoft/signalr';

export const environment = {
  production: false,
  hubUrl: 'https://localhost:7169/my-hub',
  signalrLogLevel: signalR.LogLevel.Debug
};
