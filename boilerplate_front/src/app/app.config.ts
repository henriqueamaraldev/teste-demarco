import { provideHttpClient } from '@angular/common/http';
import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideRouter, withInMemoryScrolling } from '@angular/router';
import { DocumentService, DomRefService, EventListenerService, JoyrideBackdropService, JoyrideOptionsService, JoyrideService, JoyrideStepsContainerService, JoyrideStepService, LoggerService, StepDrawerService, TemplatesService } from 'ngx-joyride';
import { MessageService } from 'primeng/api';
import { routes } from './app.routes';
import { BaseService } from './core/services/base/base.service';

const joyrideServices = [
  JoyrideService,
  JoyrideStepService,
  JoyrideBackdropService,
  DocumentService,
  DomRefService,
  JoyrideOptionsService,
  EventListenerService,
  JoyrideStepsContainerService,
  LoggerService,
  StepDrawerService,
  TemplatesService
]

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes, withInMemoryScrolling({
      scrollPositionRestoration: "enabled"
    })),
    provideAnimationsAsync(),
    provideHttpClient(),
    JoyrideService,
    MessageService,
    BaseService,
    ...joyrideServices
  ]
};
