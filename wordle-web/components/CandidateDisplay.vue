<template>
    <v-container>
        <v-row justify="center">
            <v-col cols="6">
                <v-list>
                    <v-list-item v-for="c in candidatesArray" :key="c">
                        {{c}}
                    </v-list-item>
                </v-list>
            </v-col>
        </v-row>
    </v-container>    
</template>

<script lang="ts">
import {Component, Prop, Vue} from 'vue-property-decorator'

@Component
export default class CandidateDisplay extends Vue
{
    @Prop({required: true})
    candidatesArray!: string[]
}
</script>