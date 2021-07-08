<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/parameter/ParameterList" :class="{active:'/parameter/ParameterList' === $route.path}">参数管理</router-link>
                <!--<router-link tag="li" to="/setting/menu" :class="{active:'/setting/menu' === $route.path}">菜单管理</router-link>-->
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>
