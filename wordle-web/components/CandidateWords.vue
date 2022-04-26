<template>
    <v-container>
        <v-row>
            <v-col>
                <v-list>
                    <v-list-item v-for="c in candidates" :key="c">
                        <v-list-item-content>
                            {{c}}
                        </v-list-item-content>
                    </v-list-item>
                </v-list>
            </v-col>
        </v-row>
    </v-container>    
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import {WordsService} from '~/scripts/wordsService'

@Component
export default class CandidateWords extends Vue
{
    word: string
    candidatesList: string[]

    constructor()
    {
        super()
        this.word = ''
        this.candidatesList = []
    }

    update(current: string)
    {
        this.candidatesList = WordsService.getCandWords(current);
        for(const str of this.candidatesList)
        {
            console.log(str);
        }
    }
}
</script>