<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/inject/list" :class="{active:'/inject/list' === $route.path}">产品列表</router-link>
                <router-link tag="li" to="/inject/inspectionParam" :class="{active:'/inject/inspectionParam' === $route.path}">产品检测参数</router-link>
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>