<template>
  <v-container>
    <v-btn small justify="left" @click="emit(c)"
      >{{ candidatesArray.length }} potential words. See List?
    </v-btn>
    <v-row justify="center">
      <v-col cols="6">
        <v-card height="120px" flat color="transparent">
          <v-btn v-if="!display" class="justify-center" @click="show">
            {{candidatesArray.length}} Available
          </v-btn>
        <v-list max-height="120px" v-if="display" dense class="overflow-y-auto">
          <v-list-item
            v-for="c in candidatesArray"
            :key="c"
            class="justify-center"
          >
            {{ c }}
          </v-list-item>
        </v-list>
        </v-card>
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

  @Prop({required: true})
  display!: boolean

  emit(c: string) {
    this.$emit('fill-word', c)
    this.hide()
  }

  show()
  {
    this.display = true;
  }

  hide()
  {
    this.display = false;
  }

  mounted()
  {
    this.hide()
  }
}
</script>
