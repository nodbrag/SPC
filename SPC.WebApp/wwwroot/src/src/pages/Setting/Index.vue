<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/setting/user" :class="{active:'/setting/user' === $route.path}">用户管理</router-link>
                <router-link tag="li" to="/setting/role" :class="{active:'/setting/role' === $route.path}">角色管理</router-link>
                <!--<router-link tag="li" to="/setting/menu" :class="{active:'/setting/menu' === $route.path}">菜单管理</router-link>-->
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>
