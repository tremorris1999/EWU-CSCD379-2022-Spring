import Vue from "vue";
import Component from "vue-class-component";

@Component
export default class WordService extends Vue
{
    isLoading: boolean = false;

    mounted()
    {
        setTimeout(() => { this.isLoading = true; }, 3000);
    }

    checkLength(str: string)
    {
       return (str.length == 5);
    }
}