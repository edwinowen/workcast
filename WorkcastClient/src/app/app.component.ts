import { Component, OnInit } from '@angular/core';
import { WorkcastQueueService } from 'src/app/services/workcast-queue.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title : string = 'WorkcastClient';
  command : string;
  lastCommand;
  queue;

  constructor(private queueService : WorkcastQueueService) {}

  ngOnInit() : void {
    this.updateQueue();
  }

  enqueue() : void {
    if (this.command.length < 5) {
      alert("Command is too short!");
      return;
    }
    this.queueService.enqueue(this.command).subscribe({
      next: response => {
        this.updateQueue();
      }
    });
  }

  dequeue() : void {
    this.queueService.dequeue().subscribe({
      next: response => {
        this.lastCommand = response;
        this.updateQueue();
      },
      error: err => {
        this.lastCommand = "No Commands Found"
      }
    });
  }

  seed() : void {
    this.queueService.seed().subscribe({
      next: () => this.updateQueue()
    });
  }

  updateQueue() : void {
    this.queueService.getQueue().subscribe({
      next: response => {
        this.queue = response;
        console.log(response)
      }
    });
  }

  onKey(e) {
    this.command = e.target.value;
  }

}
