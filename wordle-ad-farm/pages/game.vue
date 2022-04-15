<template>
    
    <v-card class='content-vue' >
        
        <v-card v-if="!isLoaded" loading >
            <!-- pre view -->
            
            <!-- <v-row > -->
            
            <p>you're being exploited for ad revenue. please wait a moment...</p>
            <PrerollAd />             
       <!-- </v-row> -->
        </v-card>

    <v-card v-if="isLoaded">
        <NuxtLogo />
        <VuetifyLogo />
        <v-card-text>
            <h1>thanks for playing our game!</h1>
            <v-btn color="primary" nuxt to="/"> 
            <!-- index.vue is implicit, so only route to / -->
                home page
            </v-btn>
        </v-card-text>
           
    </v-card>
       
    

    </v-card>
</template>

<script lang="ts">
import Vue from "vue"
import Component from "vue-class-component"

@Component
export default class Game extends Vue
{
    isLoaded: boolean = false;

    mounted()
    {
        setTimeout(() => { this.isLoaded = true; }, 5000);
    }
}
</script>