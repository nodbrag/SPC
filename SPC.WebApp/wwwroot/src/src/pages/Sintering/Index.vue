<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/sintering/detail" :class="{active:'/sintering/detail' === $route.path}">烧结详情</router-link>
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>