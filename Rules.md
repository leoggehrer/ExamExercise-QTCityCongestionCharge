# Fee table  

The following table summarizes the charges for the individual vehicles.  

|Vehicle   |driving  |parking  |rush hour  |Max     |   
|----------|---------|---------|-----------|--------|  
|FF..Fossile fuels | 1 EUR   | 1 EUR   | + 3 EUR   | 20 EUR |  
|EV..Electric vehicles | 0 EUR   | 0 EUR   | + 3 EUR   | 20 EUR |  
|HEV..Hybrid electric vehicles       | 0 EUR   | 0 EUR   | + 3 EUR   | 20 EUR |  
|Lorry     | 1,5 EUR | 1,5 EUR | + 4,5 EUR | 30 EUR |  
|Van       | 1,5 EUR | 1,5 EUR | + 4,5 EUR | 30 EUR |  
|Motorcycle| 0,5 EUR | 0,5 EUR | + 1,5 EUR | 10 EUR |  

## Table of peak times  

|Day      |From |To   |  
|---------|-----|-----|  
|Monday   |07:30|10:00|  
|Monday   |15:30|18:00|  
|Tuesday  |07:30|10:00|  
|Tuesday  |15:30|18:00|  
|Wednesday|07:30|10:00|  
|Wednesday|15:30|18:00|  
|Thursday |07:30|10:00|  
|Thursday |15:30|18:00|  
|Friday   |07:30|10:00|  
|Friday   |15:30|18:00|  

## Weekend  

There are no fees on weekends (Saturday and Sunday).  

### Test Cases for Fee Calculation  
**Example 1:** Driving to Linz for work  
A passenger car running on fossile fuels enters Linz on a Tuesday at 8:30am and leaves Linz on the same day at 4:15pm.  

1 EUR for 8am-9am  
1 EUR for 9am-10am  
1 EUR for 10am-11am  
1 EUR for 11am-12am  
1 EUR for 12am-1pm  
1 EUR for 1pm-2pm  
1 EUR for 2pm-3pm  
1 EUR for 3pm-4pm  
1 EUR for 4pm-5pm  
3 EUR for driving during rush hour  
3 EUR for driving during rush hour  

Total fee is 9 * 1 EUR + 3 EUR + 3 EUR = 15 EUR  
The same trip done with a lorry would cost 15 EUR + 50% = 22,5 EUR. The same trip done with a motorcycle would cost 15 EUR - 50% = 7,5 EUR.  

**Example 2:** Staying in Linz for vacation  
A passenger car running on fossile fuels enters Linz on a Monday at 3:45pm and leaves Linz on the following Friday at 2:15pm. It was detected driving on streets inside Linz on Wednesday at 9:15am, on Thursday at 4:45pm, and on Friday at 8:45am.  

Monday: 9 EUR + 3 EUR = 12 EUR  
Tuesday: 20 EUR (because of max. payment per day)  
Wednesday: 20 EUR (because of max. payment per day)  
Thursday: 20 EUR (because of max. payment per day)  
Friday: 15 EUR + 3 EUR + 1 EUR = 19 EUR  
Total fee is 91 EUR  

**Example 3:** Driving to Linz for party  
A passenger car running on fossile fuels enters Linz on a Saturday at 5:00pm and leaves Linz on the following calendar day at 1:30am (night).  

Saturday: 7 * 1 EUR = 7 EUR  
Sunday: 2 * 1 EUR = 2 EUR  
No Congestion Charge because of weekend  

**Example 4:** Driving in Linz with EV  
An EV enters Linz on a Tuesday at 8:30am and leaves Linz on the same day at 4:15pm.  

Fee to pay is 3 EUR (CC). The same trip done with a lorry would cost 3 EUR + 50% = 4.5 EUR. The same trip done with a motorcycle would cost 3 EUR - 50% = 1.5 EUR.  

**Example 5:** Staying in Linz for vacation with EV  
An electric passenger car enters Linz on a Monday at 12:30pm and leaves Linz on the following Friday at 2:15pm. The car was parked during the entire vacation because travelers took public transport in Linz.  

On all days between Monday and Friday there is no fee to pay.  

**Example 6:** Work and shopping trip on one day  
A passenger car running on fossile fuels enters Linz on a Monday at 8:45am and leaves Linz at 3:15pm. The car enters Linz on the same Monday at 5:10pm and leaves again at 6:30pm.  

1 EUR for 8am-9am  
1 EUR for 9am-10am  
1 EUR for 10am-11am  
1 EUR for 11am-12am  
1 EUR for 12am-1pm  
1 EUR for 1pm-2pm  
1 EUR for 2pm-3pm  
1 EUR for 3pm-4pm  
1 EUR for 5pm-6pm  
1 EUR for 6pm-7pm  
3 EUR for driving during rush hour  
Total fee is 10 * 1 EUR + 3 EUR = 13 EUR  
The same trip done with a lorry would cost 13 EUR + 50% = 19.5 EUR. The same trip done with a motorcycle would cost 13 EUR - 50% = 6.5 EUR.  

**Example 7:** Still in Linz  
A passenger car running on fossile fuels entered Linz two days ago at 1:10pm. The car has not left Linz yet.  

Fee for the day the car entered: 11 * 1 EUR = 11 EUR  
Fee for yesterday: 20 EUR  
Fee for today cannot be calculated yet because car might still leave the city.  

**Example 8:** Short visit  
A passenger car running on fossile fuels entered Linz on a Monday at 1:10pm and left half an hour later at 1:40pm.  

Fee to pay is 1 EUR. The same trip done with a lorry would cost 1 EUR + 50% = 1.5 EUR. The same trip done with a motorcycle would cost 1 EUR - 50% = 0.5 EUR.  

**Example 9:** Edge case  
A passenger car running on fossile fuels entered Linz on a Monday at 1:10pm and left the same day at 2:00pm.  

Fee to pay is 2 EUR because 2:00pm counts as a new, started wall-clock-hour.  
