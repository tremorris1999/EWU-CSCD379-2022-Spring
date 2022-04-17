export { default as NotWordleLogo } from '../../components/NotWordleLogo.vue'
export { default as NuxtLogo } from '../../components/NuxtLogo.vue'
export { default as PrerollAd } from '../../components/PrerollAd.vue'
export { default as Tutorial } from '../../components/Tutorial.vue'
export { default as VuetifyLogo } from '../../components/VuetifyLogo.vue'
export { default as GameBoard } from '../../components/game-board.vue'
export { default as Keyboard } from '../../components/keyboard.vue'

// nuxt/nuxt.js#8607
function wrapFunctional(options) {
  if (!options || !options.functional) {
    return options
  }

  const propKeys = Array.isArray(options.props) ? options.props : Object.keys(options.props || {})

  return {
    render(h) {
      const attrs = {}
      const props = {}

      for (const key in this.$attrs) {
        if (propKeys.includes(key)) {
          props[key] = this.$attrs[key]
        } else {
          attrs[key] = this.$attrs[key]
        }
      }

      return h(options, {
        on: this.$listeners,
        attrs,
        props,
        scopedSlots: this.$scopedSlots,
      }, this.$slots.default)
    }
  }
}
