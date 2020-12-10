import { HttpClientModule } from '@angular/common/http'
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AUTH_API_URL, BEE_FARM_API_URL } from './app-injections-tokens';
import { environment } from 'src/environments/environment';
import { JwtModule } from '@auth0/angular-jwt'
import { ACCESS_TOKEN_KEY } from './services/auth.service';
import { CommonModule } from '@angular/common';

export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: environment.allowedDomains
      }
    })
  ],
  providers: [{
    provide: AUTH_API_URL,
    useValue: environment.authApi
  },
  {
    provide: BEE_FARM_API_URL,
    useValue: environment.beeFarmApi
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
