import { Component } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { RealTimeDataService } from './shared/services/real-time.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  readonly informations: string[] = [];

  constructor(private matIconRegistry: MatIconRegistry, private realTimeService: RealTimeDataService) {
    this.matIconRegistry.setDefaultFontSetClass('material-symbols-outlined');
    this.realTimeService.init();

    this.realTimeService.information$.subscribe(m => this.informations.push(m));
  }
}
