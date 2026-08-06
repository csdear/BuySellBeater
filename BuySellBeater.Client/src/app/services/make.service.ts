import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Make } from '../models/make.model';

@Injectable({
  providedIn: 'root'
})
export class MakeService {
  private http = inject(HttpClient);
  private apiUrl = '/api/makes';

  getMakes(): Observable<Make[]> {
    return this.http.get<Make[]>(this.apiUrl);
  }
}
