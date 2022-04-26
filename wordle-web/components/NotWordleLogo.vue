<template>
  <v-icon class="notwordle-logo" size="180">mdi-file-word-box</v-icon>
</template>

<style>
.notwordle-logo {
  max-height: 180px;
  max-width: 180px;
  transform: rotateY(720deg);
  animation: turn 2.5s ease-out forwards 0.5s;
}

@keyframes turn {
  100% {
    transform: rotateY(0deg);
  }
}
</style>
