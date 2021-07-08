<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/spcAnalysis/TaskList" :class="{active:'/spcAnalysis/TaskList' === $route.path}">批次列表</router-link>
                <router-link tag="li" to="/spcAnalysis/Analysis" :class="{active:'/spcAnalysis/Analysis' === $route.path}">SPC分析</router-link>
                <router-link tag="li" to="/spcAnalysis/CausalityAnalysis" :class="{active:'/spcAnalysis/CausalityAnalysis' === $route.path}">因果分析</router-link>
                <router-link tag="li" to="/spcAnalysis/ComparativeAnalysis" :class="{active:'/spcAnalysis/ComparativeAnalysis' === $route.path}">对比分析</router-link>
                <!--<router-link tag="li" to="/spcAnalysis/EchartsClass" :class="{active:'/spcAnalysis/EchartsClass' === $route.path}">图表例</router-link>-->
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>
