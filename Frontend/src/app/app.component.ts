import { Component } from '@angular/core';
import { BeeGarden } from './models/beeGarden';
import { BeeGardenService } from './services/bee-garden.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public beeGardens: BeeGarden[] = [];
  // public get isLoggedIn() : boolean {
  //   return this.authService.isAuthenticated();
  // }

  // public get beeGardens() : BeeGarden[] {
  //   return this.beeGardenService.getAllBeeGardens()
  //     .subscribe(b => { this.});
  // }

  constructor(private beeGardenService: BeeGardenService) {}

  ngOnInit() : void {
    this.beeGardenService.getAllBeeGardens()
      .subscribe(res => {
        this.beeGardens = res
      });
  }


}