import Vue from "vue";
import Component from "vue-class-component";
import { LoaderOptionsPlugin } from "webpack";

@Component
export default class WordService extends Vue
{
    waitASec:boolean;
    created() 
    {
        setTimeout(()=> {console.log("making you look at our ads")},1000)
    }
    checkLength(str: string)
    {
       return (str.length == 5);
    }
}