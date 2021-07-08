<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/dimension/list" :class="{active:'/dimension/list' === $route.path}">测量数据列表</router-link>
                <div v-if="$route.path === '/dimension/detail'">
                    <li class="router-link-active active">数据详情</li>
                    <!-- <router-link tag="li" to="/dimension/detail" :class="{active:'/dimension/detail' === $route.path}">检测详情</router-link> -->
                </div>
                <div v-if="$route.path === '/dimension/summary'">
                    <li class="router-link-active active">信息汇总</li>
                    <!-- <router-link tag="li" to="/dimension/summary" :class="{active:'/dimension/summary' === $route.path}">信息汇总</router-link> -->
                </div>
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>