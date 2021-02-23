from django.shortcuts import render
import calendar
from calendar import HTMLCalendar
from datetime import datetime
from .models import Event


def all_events(request):
    event_list = Event.objects.all()
    return render(request, 'events/event_list.html', {'event_list': event_list})


def home(request, year=datetime.now().year, month=datetime.now().strftime('%B')):
    name = "Cesar"
    month = month.capitalize()
    month_numer = list(calendar.month_name).index(month)
    month_numer = int(month_numer)

    cal = HTMLCalendar().formatmonth(year, month_numer)

    now = datetime.now()
    current_year = now.year
    time = now.strftime('%I:%M:%S %p')
    return render(request,
                  'events/home.html', {
                      "first_name": name,
                      "year": year,
                      "month": month,
                      "month_numer": month_numer,
                      "cal": cal,
                      "current_year": current_year,
                      "time": time,

                  })
