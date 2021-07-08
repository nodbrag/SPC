<template>
    <div>
       <Top v-if="$route.meta.showNav" />
       <Nav v-if="$route.meta.showNav" />
       <div :class="{ main_container: $route.meta.showNav }">
         <router-view>11</router-view>
       </div>
    </div>
</template>

<script>
import Nav from '../src/components/Nav/Nav.vue'
import Top from '../src/components/Top/Top.vue'
export default {
  components: {
    Nav,
    Top
  }
}
</script>

<style lang="stylus" scoped>
.main_container
  margin-left 250px
  //height calc(100vh - 60px)
  border-left: 1px solid #DDDDDD;
</style>
