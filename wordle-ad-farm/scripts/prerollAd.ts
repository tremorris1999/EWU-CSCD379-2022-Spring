import Vue from "vue"
import Component from "vue-class-component"

@Component
export default class PrerollAd extends Vue
{
    isLoading: boolean = false;

    mounted()
    {
        setTimeout(() => { this.isLoading = true; }, 3000);
    }
}