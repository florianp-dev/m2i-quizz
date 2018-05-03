import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AnswerComponent } from './components/answer/answer.component';
import {AnswersService} from './Services/answers.service';
import { QuestionsComponent } from './components/questions/questions.component';
import {QuestionsService} from './Services/questions.service';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    AnswerComponent,
    QuestionsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    AnswersService,
    QuestionsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
