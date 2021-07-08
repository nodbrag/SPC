<template>
    <div>
        <!-- 检测信息 -->
        <el-card class="box-card-analysis" v-show="showTable">
            <div slot="header" class="clearfix">
                <span>检测信息</span>
                <el-button @click="fullScreen" style="float: right; padding: 3px 0" type="text">
                  <i v-show="showChart" class="font_family icon-enlarge icon-operate"></i>
                  <i v-show="!showChart" class="font_family icon-narrow icon-operate"></i>
                </el-button>
                <el-button style="float: right; padding: 3px 0" type="text" @click="showSeachModal"><i class="font_family icon-screen icon-operate"></i></el-button>
            </div>
            <template>
                <el-table 
                    ref="table"
                    :data="tableData"
                    :height="height"
                    :header-cell-style='styleObj'
                    style="width: 100%">
                    <el-table-column
                    prop="no"
                    label="检测批次"
                    >
                    </el-table-column>
                    <el-table-column
                    prop="productName"
                    label="产品"
                    >
                    </el-table-column>
                    <el-table-column
                    prop="checkQuantity"
                    label="抽检数量">
                    </el-table-column>
                    <el-table-column
                    prop="unqualifiedRate"
                    label="不合格品率(%)">
                    </el-table-column>
                    <el-table-column
                    prop="unqualifiedCount"
                    label="不合格总数">
                    </el-table-column>
                    <el-table-column
                    prop="bad_hh"
                    label="不良：划痕">
                    </el-table-column>
                    <el-table-column
                    prop="bad_mb"
                    label="不良：毛边">
                    </el-table-column>
                    <el-table-column
                    prop="bad_xb"
                    label="不良：形变">
                    </el-table-column>
                    <el-table-column
                    prop="bad_xc"
                    label="不良：瑕疵">
                    </el-table-column>
                    <el-table-column
                    prop="bad_zd"
                    label="不良：杂点">
                    </el-table-column>
                </el-table>
            </template>
        </el-card>
        <!-- 统计图表 -->
        <el-card class="box-card-analysis" v-show="showChart">
            <div slot="header" class="clearfix">
                <span>统计图表</span>
                <el-button @click="fullScreenChart" style="float: right; padding: 3px 0" type="text">
                  <i v-show="showTable" class="font_family icon-enlarge icon-operate"></i>
                  <i v-show="!showTable" class="font_family icon-narrow icon-operate"></i>
                </el-button>
            </div>
            <div class="chart-container" :height="height" :style={height:height}>
                <div class="chart-btn-box" v-if="!showChartList">
                  <el-tabs :tab-position="tabPosition" v-model="activeName">
                    <el-tab-pane name="1">
                      <span slot="label" class="chart-btn"><i class="font_family icon-controlchart icon-chart"></i> 控制图</span>
                      <ve-line :extend="chartExtend" ref="chart1"></ve-line>
                    </el-tab-pane>
                    <el-tab-pane name="2">
                      <span slot="label" class="chart-btn"><i class="font_family icon-Permutationchart icon-chart"></i> 柏拉图</span>
                      <ve-line :extend="chartExtend2" ref="chart2"></ve-line>
                    </el-tab-pane>
                    <el-tab-pane name="3">
                      <span slot="label" class="chart-btn"><i class="font_family icon-Analysischart icon-chart"></i> 良品率分析</span>
                      <ve-line :extend="chartExtend3" ref="chart3"></ve-line>
                    </el-tab-pane>
                    <el-tab-pane name="4">
                      <span slot="label" class="chart-btn not-allow"><i class="font_family icon-ODfenxituCopy icon-chart"></i> 正太检验</span>
                      <div class="nodata">
                        <i class="font_family icon-zanwushuju"></i>
                        <p>暂无数据</p>
                      </div>
                    </el-tab-pane>
                    <el-tab-pane name="5">
                      <span slot="label" class="chart-btn not-allow"><i class="font_family icon-meanvalue icon-chart"></i> 均值极差图</span>
                      <div class="nodata">
                        <i class="font_family icon-zanwushuju"></i>
                        <p>暂无数据</p>
                      </div>
                    </el-tab-pane>
                    <el-tab-pane name="6">
                      <span slot="label" class="chart-btn not-allow"><i class="font_family icon-CPK icon-chart"></i> CPK分析图</span>
                      <div class="nodata">
                        <i class="font_family icon-zanwushuju"></i>
                        <p>暂无数据</p>
                      </div>
                    </el-tab-pane>
                  </el-tabs>
                </div>
                <div class="chart-list" v-if="showChartList">
                  <el-card class="chart-list-item">
                    <div slot="header" class="clearfix">
                        <span>不良率（P）控制图</span>
                    </div>
                    <ve-line :extend="chartExtend"></ve-line>
                  </el-card>
                  <el-card class="chart-list-item">
                    <div slot="header" class="clearfix">
                        <span>柏拉图（排列图）</span>
                    </div>
                    <ve-histogram :extend="chartExtend2"></ve-histogram>
                  </el-card>
                  <el-card class="chart-list-item">
                    <div slot="header" class="clearfix">
                        <span>良品率趋势图</span>
                    </div>
                    <ve-line :extend="chartExtend3"></ve-line>
                  </el-card>
                </div>
            </div>
        </el-card>
        <!-- 搜索数据的弹框 -->
        <!-- <SearchModel :dialogFormVisible="this.dialogFormVisible"/> -->
        <el-dialog title="数据查询" :visible.sync="dialogFormVisible" center class="SearchModal">
          <el-form :model="form" :rules="rules" ref="ruleFormSearch">
            <el-form-item label="产品信息：" :label-width="formLabelWidth">
              <el-input v-model="form.productInfo" autocomplete="off"></el-input>
            </el-form-item>
            <el-form-item label="开始时间：" :label-width="formLabelWidth">
              <el-date-picker
                v-model="form.startTIme"
                type="datetime"
                placeholder="选择日期时间"
                :picker-options="pickerOptions1"
                align="right">
              </el-date-picker>
            </el-form-item>
            <el-form-item label="结束时间：" :label-width="formLabelWidth">
              <el-date-picker
                v-model="form.endTIme"
                type="datetime"
                placeholder="选择日期时间"
                :picker-options="pickerOptions1"
                align="right">
              </el-date-picker>
            </el-form-item>
            <el-form-item label="抽检批次：" :label-width="formLabelWidth">
              <el-select v-model="form.samplingBatch" placeholder="请选择抽检批次">
                <el-option label="抽检批次1" value="shanghai"></el-option>
                <el-option label="抽检批次2" value="beijing"></el-option>
              </el-select>
            </el-form-item>
            <el-form-item label="不良类型：" :label-width="formLabelWidth">
              <el-select v-model="form.badType" placeholder="请选择不良类型">
                <el-option label="不良类型1" value="shanghai"></el-option>
                <el-option label="不良类型2" value="beijing"></el-option>
              </el-select>
            </el-form-item>
          </el-form>
          <div slot="footer" class="dialog-footer">
            <el-button @click="dialogFormVisible = false">取 消</el-button>
            <el-button type="primary" @click="dialogFormVisible = false">确 定</el-button>
          </div>
        </el-dialog>
    </div>
</template>

<script>
import Vue from 'vue'
import VCharts from 'v-charts'
Vue.use(VCharts)
export default {
    data() {
      this.chartExtend = {
        grid : {
            right : 50,    //距离容器右边界50像素
        },
        tooltip: {
            trigger: 'axis'
        },
        legend: {
            data:['high', 'low', '不良率']
        },
        xAxis: {
            axisLabel: {
                interval:0,
                rotate:-40
            },
            data: ['12:05:00', '12:10:00', '12:15:00', '12:20:00', '12:25:00', '12:30:00', '12:35:00', '12:40:00','12:45:00','12:50:00']
        },
        yAxis: {
            type: 'value'
        },
        series: [
            {
                name:'high',
                type:'line',
                step: 'start',
                smooth: false,
                itemStyle: {
                    normal: {
                      color: "#E84950",//折线点的颜色
                      lineStyle: {
                      color: "#E84950"//折线的颜色
                      }
                    }
                },
                data:[0.07, 0.08, 0.075, 0.06, 0.055, 0.069, 0.08, 0.07, 0.06, 0.1]
            },
            {
                name:'low',
                type:'line',
                step: 'end',
                smooth: false,
                itemStyle: {
                    normal: {
                      color: "#E84950",//折线点的颜色
                      lineStyle: {
                      color: "#E84950"//折线的颜色
                      }
                    }
                },
                data:[0.01, 0.019, 0.02, 0.005, 0.03, 0.009, 0.03, 0.026, 0.005, 0.023]
            },
            {
                name:'不良率',
                type: 'line',
                smooth: false,
                markLine: {
                  data : [
                    {type : 'average', name: '平均值'}
                  ]
                },
                itemStyle: {
                    normal: {
                      color: "#2E5BFF",//折线点的颜色
                      lineStyle: {
                      color: "#2E5BFF"//折线的颜色
                      }
                    }
                },
                data:[
                  {value:'0.02',symbol:'none'},
                  {value:'0.034',symbol:'none'},
                  {value:'0.07',symbol:'none'},
                  {value:'0.04',symbol:'none'},
                  {value:'0.023',symbol:'none'},
                  {value:'0.03',symbol:'none'},
                  {value:'0.09',symbol:'circle',symbolSize:'10',itemStyle: 
                    {
                      color: "#E84950",//折线的颜色,
                      shadowColor: '#E84950',
                      shadowBlur: 20,
                      shadowOffsetX: 0,
                      shadowOffsetY: 0,
                      opacity: 1
                    }
                  },
                  {value:'0.04',symbol:'circle',symbolSize:'10'},
                  {value:'0.05',symbol:'circle',symbolSize:'10'},
                  {value:'0.1',symbol:'circle',symbolSize:'10'},
                ]
            }
        ]
      };
      this.chartExtend2 = {
        color: ['#2E5BFF'],
        grid : {
            right : 50,    //距离容器右边界50像素
        },
        tooltip: {
            trigger: 'axis'
        },
        legend: {
            data:['high', 'low', '不良率']
        },
        xAxis: {
            type: 'category',
            axisLabel: {
                interval:0,
                rotate:-40
            },
            splitLine:{show: true,color:'#ccc'},//去除网格线
            data: ['毛边', '杂点', '凹凸', '划痕', '杂色', '形变', '毛边', '杂点', '凹凸', '划痕', '杂色', '形变']
        },
        yAxis: {
            type: 'value'
        },
        barWidth:'20',
        barGap:'100%',
        itemStyle: {
				barBorderRadius: [10, 10, 0, 0],
				barWidth:'10'
		    },
        series: [{
            data: [
              {value:'50',itemStyle: 
                {
                  color: "#8C54FF",
                }
              },
              {value:'45'},
              {value:'43'},
              {value:'40'},
              {value:'38'},
              {value:'35'},
              {value:'29'},
              {value:'35'},
              {value:'38'},
              {value:'30'},
              {value:'28'},
              {value:'20'},
            ],
            type: 'bar'
        }]
      };
      this.chartExtend3 = {
        grid : {
            right : 50,    //距离容器右边界50像素
        },
        tooltip: {
            trigger: 'axis'
        },
        legend: {
            data:['不良率']
        },
        xAxis: {
            axisLabel: {
                interval:0,
                rotate:-40
            },
            data: ['1周', '2周', '3周', '4周', '5周', '6周', '7周', '8周','9周','10周','11周','12周','13周','14周','15周']
        },
        yAxis: {
            type: 'value'
        },
        series: [
            {
                name:'不良率',
                type: 'line',
                smooth: false,
                markLine: {
                  data : [
                    {type : 'average', name: '平均值'}
                  ]
                },
                itemStyle: {
                    normal: {
                      color: "#2E5BFF",//折线点的颜色
                      lineStyle: {
                      color: "#2E5BFF"//折线的颜色
                      }
                    }
                },
                data:[
                  {value:'70'},
                  {value:'75'},
                  {value:'78'},
                  {value:'79'},
                  {value:'80'},
                  {value:'95'},
                  {value:'85'},
                  {value:'80'},
                  {value:'73'},
                  {value:'85'},
                  {value:'95'},
                  {value:'85'},
                  {value:'80'},
                  {value:'73'},
                  {value:'85'},
                ]
            }
        ]
      }
      //验证表单产品信息
      var validateProductInfo = (rule, value, callback) => {
        if (!value) {
          return callback(new Error('账号不能为空'));
        } else { 
          callback();
        }
      };
      //验证表单开始时间
      var validatStartTime = (rule, value, callback) => {
        if (!value) {
          return callback(new Error('账号不能为空'));
        } else { 
          callback();
        }
      };
      return {
        activeName: '1',
        tabPosition: 'left',
        //半屏的高度
        height: "400px",
        //显示检测信息
        showTable: true,
        //显示统计图表
        showChart: true,
        //是否显示chart列表
        showChartList: false,
        //表头颜色样式
        styleObj: {
        	'background':'#F2F2F2'
        },
        //搜索数据弹框是否显示
        dialogFormVisible: false,
        //搜索数据弹框表单
        form: {
          productInfo: '',
          startTime: '',
          endTime: '',
          samplingBatch: [],
          badType: [],
        },
        formLabelWidth: '120px',
        rules: {
            productInfo: [
                { validator: validateProductInfo, trigger: 'blur' }
            ],
            startTime: [
                { validator: validatStartTime, trigger: 'blur' }
            ]
        },
        tableData: [
          {
            no: '001',
            productName: '接口配件',
            checkQuantity: '7834',
            unqualifiedRate: '4.12%',
            unqualifiedCount: '14',
            bad_hh: '6',
            bad_mb: '1',
            bad_xb: '3',
            bad_xc: '4',
            bad_zd: '2',
          },
          {
            no: '002',
            productName: '接口配件',
            checkQuantity: '7834',
            unqualifiedRate: '4.12%',
            unqualifiedCount: '14',
            bad_hh: '6',
            bad_mb: '1',
            bad_xb: '3',
            bad_xc: '4',
            bad_zd: '2',
          }
        ],
        //时间选择器
        pickerOptions1: {
          shortcuts: [{
            text: '今天',
            onClick(picker) {
              picker.$emit('pick', new Date());
            }
          }, {
            text: '昨天',
            onClick(picker) {
              const date = new Date();
              date.setTime(date.getTime() - 3600 * 1000 * 24);
              picker.$emit('pick', date);
            }
          }, {
            text: '一周前',
            onClick(picker) {
              const date = new Date();
              date.setTime(date.getTime() - 3600 * 1000 * 24 * 7);
              picker.$emit('pick', date);
            }
          }]
        }
      }
    },
    methods: {
      fullScreen() {
        this.height = this.height === "400px" ? window.innerHeight - 100 + "px" : "400px"
        this.showChart = !this.showChart
      },
      fullScreenChart() {
        this.height = this.height === "400px" ? window.innerHeight - 100 +"px" : "400px"
        this.showTable = !this.showTable
        this.showChartList = !this.showChartList
      },
      showSeachModal() {
        this.dialogFormVisible = !this.dialogFormVisible
      }
    },
    watch: {
      activeName (v) {
        this.$nextTick(_ => {
          this.$refs[`chart${v}`].echarts.resize()
        })
      }
    }
}
</script>

<style lang="stylus" scope>
.el-card__header{
    border-left 4px solid #E7E7E7
    background: #F8F8F8;
    border-bottom 0;
    font-size 19px;
    color: #696969; 
    line-height: 20px;
    span {
        font-weight: bold;
    }
}
.box-card-analysis .el-card__body {
    padding 0;
}
.chart-container { 
    min-height 400px
}
.chart-btn-box {
    overflow hidden
    padding-top 20px;
    .el-tabs__header{
      width 14%
      max-width 150px
    }
    .el-tabs__content{
      width 84%
    }
  .el-tabs__item{
    padding 0
    margin-bottom 10px
    background: #f3f3f3;
    display: block;
    text-align: center;
    font-size: 14px;
    color: #666;
    text-align: center!important;
  }
  .el-tabs__item.is-active{
    background #EFEFEF
    color #000
  }
  .el-tabs__nav-wrap::after{
    background transparent
  }
  .el-tabs__active-bar{
    width 0!important
  }
}
.icon-chart {
  margin-right 15px
  font-size 14px
  color #666
}
.icon-operate { 
  font-size 20px
  color #666
  padding: 0 8px;
}
.SearchModal {
  .el-dialog__header {
    .el-dialog__title {
      font-size 24px
      color #696969
      padding 0 30px 15px
      border-bottom 3px solid #9E9E9E
    }
  }
  .el-input {
    width 100%!important
  }
  .el-select{
    width 100%
  }
}

.chart-list {
  overflow-y: scroll;
  height: 880px;
  .chart-list-item {
    .el-card__header {
      margin-top: 20px
    }
  }
}
.nodata {
  color: #ccc;
  text-align: center;
  i {
    font-size: 200px;
  }
}
</style>
