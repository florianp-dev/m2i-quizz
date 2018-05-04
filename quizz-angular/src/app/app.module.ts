import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AnswerComponent } from './components/answer/answer.component';
import {AnswersService} from './Services/answers.service';
import { QuestionsComponent } from './components/questions/questions.component';
import {QuestionsService} from './Services/questions.service';
import {HttpClientModule} from '@angular/common/http';

import {ROUTES} from './app.routes';
import {RouterModule} from '@angular/router';
import { QuizzComponent } from './components/quizz/quizz.component';

@NgModule({
  declarations: [
    AppComponent,
    AnswerComponent,
    QuestionsComponent,
    QuizzComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [
    AnswersService,
    QuestionsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
