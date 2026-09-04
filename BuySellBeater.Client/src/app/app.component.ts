import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MakeService } from './services/make.service';
import { Make } from './models/make.model';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HttpClientModule, MatToolbarModule, MatButtonModule, MatCardModule, VehicleFormComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'BuySellBeater.Client';
  private makeService = inject(MakeService);

  makes: Make[] = [];
  loading = true;
  errorMessage = '';

  ngOnInit(): void {
    this.makeService.getMakes().subscribe({
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
}
