<template>
  <img class="notwordle-logo" alt="!Wordle Logo" src="/file-word-box.svg" />
</template>

<style>
.notwordle-logo {
  height: 180px;
  width: 180px;
  transform: rotateY(720deg);
  animation: turn 2.5s ease-out forwards 0.5s;
}

@keyframes turn {
  100% {
    transform: rotateY(0deg);
  }
}
</style>
