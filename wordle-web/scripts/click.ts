import { useSound } from '@vueuse/sound'

export default {
  setup() {
    const { play } = useSound('../sfx/key.mp3')

    return {
      play,
    }
  },
}
