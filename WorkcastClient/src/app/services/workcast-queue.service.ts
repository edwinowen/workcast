import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class WorkcastQueueService {
  
  apiUrl = "https://localhost:5001/api/commandqueue/";

  constructor(private http : HttpClient) { }

  getQueue() : Observable<any> {
    return this.http.get(this.apiUrl + "queue").pipe(
      catchError(this.handleError)
    );
  }
  seed() : Observable<any> {
    return this.http.get(this.apiUrl + "seed").pipe(
      catchError(this.handleError)
    );
  }
  dequeue() : Observable<any> {
    return this.http.get(this.apiUrl + "dequeue").pipe(
      catchError(this.handleError)
    );
  }
  enqueue(command: string) : Observable<any> {
    return this.http.post(this.apiUrl + "enqueue?comm=" + command, {}).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(err : HttpErrorResponse) {
    let errorMessage;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occured: ${err.error.message}`;
    }
    else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(err);
  }
}
