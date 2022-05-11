<template>
  <v-img class="notwordle-logo" src="logo.jpeg" />
</template>

<style>
.notwordle-logo {
  transform: rotateY(720deg);
  animation: turn 2.5s ease-out forwards 0.5s;
}

@keyframes turn {
  100% {
    transform: rotateY(0deg);
  }
}
</style>
