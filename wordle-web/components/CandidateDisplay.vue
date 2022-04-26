<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="6">
        <v-list max-height="100px" dense nav class="overflow-y-auto">
          <v-list-item
            v-for="c in candidatesArray"
            :key="c"
            class="justify-center"
            @click="emit(c)"
          >
            {{ c }}
          </v-list-item>
        </v-list>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'

@Component
export default class CandidateDisplay extends Vue {
  @Prop({ required: true })
  candidatesArray!: string[]

  emit(c: string) {
    this.$emit('fill-word', c)
  }
}
</script>
