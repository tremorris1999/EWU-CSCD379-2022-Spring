<template>
<v-container>
    <v-card>
        <v-card-title class="justify-center">
            Word Editor
        </v-card-title>
        <v-row justify="center">
            <v-col cols="8">
    <v-text-field placeholder="Search..." 
    v-model="query"/>
            </v-col>
        </v-row>
    <v-row
    v-for="w in this.results" :key="w"
    >
    <v-col cols="1" />
    <v-col cols="3">
    {{ w }}
    </v-col>
    
    <v-col cols="3">
        <v-btn>
            Make Common
        </v-btn>
    </v-col>
    <v-col cols="3">
        <v-btn>
            Make Uncommon
        </v-btn>
    </v-col>
    <v-col cols="2">
        <v-btn>
            Delete
        </v-btn>
    </v-col>
    </v-row>
    </v-card>
</v-container>
</template>

<script lang="ts">
import { Component, Vue, Watch } from 'vue-property-decorator'

@Component
export default class WordEditor extends Vue
{
    pageSize: number = 25
    currentPage: number = 0
    wordlist: string[] = []
    results: string[] = []
    query: string = ""

    created(){
        this.$watch('query', (newQuery) => {
            this.results = []
            for(let w in this.wordlist)
            {
                if(w.match(newQuery))
                    this.results.push(w)
            }
        })
    }

    mounted()
    {
        
        this.$axios.get("/api/Word/Get")
            .then((response) => {
                this.wordlist = response.data
                this.goToPage(0)
            })
    }

    goToPage(index: number)
    {
        this.currentPage = index
        this.results = this.wordlist.slice(this.currentPage * this.pageSize, this.pageSize)
    }

    
}
</script>