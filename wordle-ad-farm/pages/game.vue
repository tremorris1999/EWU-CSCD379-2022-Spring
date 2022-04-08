<template>
    
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component
export default class WordService extends Vue
{
    checkLength(str: string)
   {
       return (str.length == 5);
   }
}
</script>