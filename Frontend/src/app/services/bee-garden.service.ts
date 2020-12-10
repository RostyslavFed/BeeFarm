import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BEE_FARM_API_URL } from '../app-injections-tokens';
import { BeeGarden } from '../models/beeGarden';

@Injectable({
  providedIn: 'root'
})
export class BeeGardenService {

  private baseApiUrl = `${this.apiUrl}api/`;

  constructor (private http: HttpClient, @Inject(BEE_FARM_API_URL) private apiUrl: string) {}

  getAllBeeGardens(): Observable<BeeGarden[]> {
    return this.http.get<BeeGarden[]>(`${this.baseApiUrl}beegardens`)
  }


}