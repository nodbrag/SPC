<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/discrete/DiscreteList" :class="{active:'/discrete/DiscreteList' === $route.path}">离散数据列表</router-link>
                <div v-if="$route.path === '/discrete/info'">
                    <!-- <router-link tag="li" to="/discrete/info" :class="{active:'/discrete/info' === $route.path}">数据详情</router-link> -->
                    <!-- <router-link tag="li" to="/discrete/info" :class="{active:'/discrete/info' === $route.path}"> {{$route.path=='/discrete/info'?'数据详情':''}}</router-link> -->
                    <li class="router-link-active active">数据详情</li>
                </div>
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>