<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/plastic/detail" :class="{active:'/plastic/detail' === $route.path}">缺陷档案</router-link>
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>