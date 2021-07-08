<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/user/UserType" :class="{active:'/user/UserType' === $route.path}">用户类型</router-link>
                <router-link tag="li" to="/user/UserList" :class="{active:'/user/UserList' === $route.path}">用户列表</router-link>
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>