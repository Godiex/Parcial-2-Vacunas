import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  ngOnInit(): void {
    var udateTime = function () {
      var Hours: string;
      var Minutes: string;
      var Seconds: string;
      var Day: string;
      var Month: string;

      let currentDate = new Date(),
        hours = currentDate.getHours(),
        minutes = currentDate.getMinutes(),
        seconds = currentDate.getSeconds(),
        day = currentDate.getDate(),
        month = currentDate.getMonth() + 1,
        year = currentDate.getFullYear();

      Day = (day < 10) ? "0" + day + "/" : day.toString() + "/";
      Month = (month < 10) ? "0" + month + "/" : month.toString() + "/";
      document.getElementById('day').textContent = Day;
      document.getElementById('month').textContent = Month;
      document.getElementById('year').textContent = year.toString();
      Hours = (hours < 10) ? "0" + hours + ":" : hours.toString() + ":";
      Minutes = (minutes < 10) ? "0" + minutes + ":" : minutes.toString() + ":";
      Seconds = (seconds < 10) ? "0" + seconds : seconds.toString();
      document.getElementById('hours').textContent = Hours;
      document.getElementById('minutes').textContent = Minutes;
      document.getElementById('seconds').textContent = Seconds;
    };
    udateTime();
    setInterval(udateTime, 1000);
  }
}