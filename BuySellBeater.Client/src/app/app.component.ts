import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { WeatherService } from './services/weather.service';
import { WeatherForecast } from './models/weather-forecast.model';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'BuySellBeater.Client';
  private weatherService = inject(WeatherService);

  forecasts: WeatherForecast[] = [];
  loading = true;
  errorMessage = '';

  ngOnInit(): void {
    this.weatherService.getWeatherForecast().subscribe({
      next: (data) => {
        this.forecasts = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error fetching weather:', err);
        this.errorMessage = 'Failed to load weather data. Make sure API is running.';
        this.loading = false;
      }
    });
  }
}
