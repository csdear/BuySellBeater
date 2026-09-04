import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Make, Vehicle } from '../../models/make.model';

@Component({
  selector: 'vehicle-form',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss']
})
export class VehicleFormComponent implements OnInit {
  private http = inject(HttpClient);
  private apiUrl = '/api/makes';

  makes: Make[] = [];
  loading = true;
  errorMessage = '';
  vehicle: Vehicle = {
    make: null,
    model: null
  };

  ngOnInit(): void {
    this.getMakes();
  }

  getMakes(): void {
    this.http.get<Make[]>(this.apiUrl).subscribe({
      next: (data) => {
        this.makes = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error fetching makes:', err);
        this.errorMessage = 'Failed to load vehicle data. Make sure the API is running and the URL is correct.';
        this.loading = false;
      }
    });
  }

  onMakeChange(): void {
    this.vehicle.model = null;
  }
}
