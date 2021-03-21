
import { Priority } from './../../models/Priorty';

interface selectInput{
  key: string;
  text: string;
  value: number;
}

export const priority =()=>
 {
   console.log(Object.keys(Priority).length);
   const PriorityOptions:selectInput[]=[];
   Object.keys(Priority).map((key:any) => {
     const prio={
       key:`${Priority[key]}s`,
       text:Priority[key],
       value:parseInt(key)
     }
     if(PriorityOptions.length ===(Object.keys(Priority).length/2)){
       return PriorityOptions;
     }
     PriorityOptions.push(prio);
   });
   return PriorityOptions;
 }
//    [
//    { key: 'drinks', text: 'Drinks', value: 'drinks' },
//    { key: 'culture', text: 'Culture', value: 'culture' },
//    { key: 'film', text: 'Film', value: 'film' },
//    { key: 'food', text: 'Food', value: 'food' },
//    { key: 'music', text: 'Music', value: 'music' },
//    { key: 'travel', text: 'Travel', value: 'travel' }
//  ]
