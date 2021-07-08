<template>
    <div class="box_index">
        <!-- 首页上面的六块面板 -->
        <div class="panel">
            <el-card class="panel_block" shadow="always">
                <div slot="header" class="clearfix">
                    <span>注射</span>
                </div>
                <div class="body">
                    <div class="box_count">
                        <span class="tit">进行批次</span>
                        <a class="num">1232</a>
                    </div>
                    <div class="column_line"></div>
                    <div class="box_count">
                        <span class="tit">总批次</span>
                        <a class="num">45345345</a>
                    </div>
                </div>
            </el-card>
            <el-card class="panel_block" shadow="always">
                <div slot="header" class="clearfix">
                    <span>摆件</span>
                </div>
                <div class="body">
                    <div class="box_count">
                        <span class="tit">进行批次</span>
                        <a class="num">1232</a>
                    </div>
                    <div class="column_line"></div>
                    <div class="box_count">
                        <span class="tit">总批次</span>
                        <a class="num">45345345</a>
                    </div>
                </div>
            </el-card>
            <el-card class="panel_block" shadow="always">
                <div slot="header" class="clearfix">
                    <span>烧结</span>
                </div>
                <div class="body">
                    <div class="box_count">
                        <span class="tit">进行批次</span>
                        <a class="num">1232</a>
                    </div>
                    <div class="column_line"></div>
                    <div class="box_count">
                        <span class="tit">总批次</span>
                        <a class="num">45345345</a>
                    </div>
                </div>
            </el-card>
            <el-card class="panel_block" shadow="always">
                <div slot="header" class="clearfix">
                    <span>整形</span>
                </div>
                <div class="body">
                    <div class="box_count">
                        <span class="tit">进行批次</span>
                        <a class="num">1232</a>
                    </div>
                    <div class="column_line"></div>
                    <div class="box_count">
                        <span class="tit">总批次</span>
                        <a class="num">45345345</a>
                    </div>
                </div>
            </el-card>
            <el-card class="panel_block" shadow="always">
                <div slot="header" class="clearfix">
                    <span>尺寸检测</span>
                </div>
                <div class="body">
                    <div class="box_count">
                        <span class="tit">进行批次</span>
                        <a class="num">1232</a>
                    </div>
                    <div class="column_line"></div>
                    <div class="box_count">
                        <span class="tit">总批次</span>
                        <a class="num">45345345</a>
                    </div>
                </div>
            </el-card>
            <el-card class="panel_block" shadow="always">
                <div slot="header" class="clearfix">
                    <span>外观检测</span>
                </div>
                <div class="body">
                    <div class="box_count">
                        <span class="tit">进行批次</span>
                        <a class="num">1232</a>
                    </div>
                    <div class="column_line"></div>
                    <div class="box_count">
                        <span class="tit">总批次</span>
                        <a class="num">45345345</a>
                    </div>
                </div>
            </el-card>
        </div>
        <!-- 首页展示的表格 -->
        <el-table
            :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
            :default-sort = "{prop: 'number', order: 'descending'}"
            stripe
            style="width: 100%">
            <el-table-column
            label="批号"
            prop="batch">
            </el-table-column>
            <el-table-column
            label="进程"
            prop="progress"
            width="400px">
                <template slot-scope="scope">
                    <Progress :progress="scope.row.progress" />
                </template>
            </el-table-column>
            <el-table-column
            label="数量"
            sortable
            prop="number">
            </el-table-column>
            <el-table-column
            align="right">
                <!---->
                <template 
                    slot="header" 
                    slot-scope="scope">
                    <el-input
                    v-model="search"
                    size="mini"
                    placeholder="输入搜索"/>
                </template>
                <template slot-scope="scope">
                    <el-dropdown>
                        <span class="el-dropdown-link">
                            <i class="el-icon-caret-bottom el-icon--right"></i>   详细
                        </span>
                        <el-dropdown-menu slot="dropdown">
                            <el-dropdown-item @click="handleEdit(scope.$index, scope.row)">编辑</el-dropdown-item>
                            <el-dropdown-item @click="handleDelete(scope.$index, scope.row)">删除</el-dropdown-item>
                        </el-dropdown-menu>
                    </el-dropdown>
                </template>
            </el-table-column>
        </el-table>
    </div>
</template>
<script>
import Progress from '../../components/Progress/Progress.vue'
export default {
    data() {
      return {
        search:'',
        tableData: [{
          batch: 'AP091',
          progress: 1,
          number:11
        }, {
          batch: 'AP092',
          progress: 2,
          number:22
        }, {
          batch: 'AP094',
          progress: 3,
          number:32
        }, {
          batch: 'AP094',
          progress: 3,
          number:32
        }, {
          batch: 'AP094',
          progress: 3,
          number:32
        }, {
          batch: 'AP094',
          progress: 3,
          number:32
        }, {
          batch: 'AP094',
          progress: 3,
          number:32
        }, {
          batch: 'AP094',
          progress: 6,
          number:32
        }]
      }
    },
    methods: {
      handleEdit(index, row) {
        console.log(index, row);
      },
      handleDelete(index, row) {
        console.log(index, row);
      }
    },
    components:{
        Progress
    }
}
</script>
<style lang="stylus" scope>
@import '../../common/common.stylus'
.box_index
    padding 20px
    .panel 
        display flex
        flex-wrap wrap
        justify-content start
        margin-bottom 5px
        .el-card 
            border-radius 8px
        .panel_block
            width 31%
            margin-bottom 20px
            height 156px
            margin-right 3%
            &:nth-child(3n)
                margin-right 0
            .el-card__header
                padding 16px 0
                text-align center
                font-size 28px
                background-color #2673FF
                color #fff
            .el-card__body 
                padding 0
            .body
                display flex
                justify-content space-around
                .box_count
                    width 50%
                    display flex
                    flex-direction column
                    .tit  
                        color #999999
                        text-align center
                        font-size 15px
                        margin-top 20px
                    .num
                        color #2673FF
                        font-size 23px
                        text-align center
                        cursor pointer
                        padding 20px 0
                .column_line
                    width 1px
                    height 53px
                    background-color #979797
                    margin-top 20px
                    opacity 0.3

    .el-table th
        background: #EEECEC!important
        color #666
        font-size 14px
    .el-table td, .el-table th
        padding 5px 0
</style>
