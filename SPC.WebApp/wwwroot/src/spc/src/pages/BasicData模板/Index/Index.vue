<template>
    <div>
        <el-row :gutter="20">
            <el-col :span="8">
                <el-card class="box-card">
                    <div slot="header" class="clearfix">
                        <span>数据汇总</span>
                        <el-button class="dot" type="text"><i class="font_family icon-more"></i></el-button>
                    </div>
                    <div class="text item card-content">
                        <div class="data-all">
                            <span class="num">1,428,290</span>
                            <span class="vertical-top">次数</span>
                        </div>
                        <ul class="data-list">
                            <li>本月检测数据为:45454</li>
                            <li>上月检测数据为:45454</li>
                        </ul>
                    </div>
                </el-card>
            </el-col>
            <el-col :span="8">
                <el-card class="box-card">
                    <div slot="header" class="clearfix">
                        <span>平均良品率(月)</span>
                        <el-button class="dot" type="text"><i class="font_family icon-more"></i></el-button>
                    </div>
                    <div class="text item card-content">
                        <div class="">
                            <ve-gauge :data="chartData" :settings="chartGaugeSettings" height="230px"></ve-gauge>
                        </div>
                        <ul class="data-list">
                            <li>上月平均良品率为:74.8%</li>
                            <li>月平均率同比增长:11.2%</li>
                            <li>预计下月良品率:97.1%</li>
                        </ul>
                    </div>
                </el-card>
            </el-col>
            <el-col :span="8">
                <el-card class="box-card">
                    <div slot="header" class="clearfix">
                        <span>预警信息</span>
                        <el-button class="dot" type="text"><i class="font_family icon-more"></i></el-button>
                    </div>
                    <div class="text item card-content">
                        <div class="">
                            <ve-ring :data="chartData2" height="230px" :extend="chartPieExtend"></ve-ring>
                        </div>
                        <ul class="data-list">
                            <li>本月报警次数:1820</li>
                            <li>上月检测次数:1428</li>
                            <li>同比上月下降:7.6%</li>
                        </ul>
                    </div>
                </el-card>
            </el-col>
            <el-col :span="24" class="mt20">
                <el-card class="box-card">
                    <div slot="header" class="clearfix">
                        <span>不良率（P）控制图</span>
                        <el-button class="dot" type="text"><i class="font_family icon-more"></i></el-button>
                    </div>
                    <div class="text item">
                        <div class="">
                            <ve-line :extend="chartExtend"></ve-line>
                        </div>
                    </div>
                </el-card>
            </el-col>
        </el-row>
    </div>
</template>

<script>
import Vue from 'vue'
import VCharts from 'v-charts'
Vue.use(VCharts)

export default {
    data () {
      this.chartGaugeSettings = {
        dataType: {
          '占比': 'percent'
        },
        seriesMap: {
          '占比': {
            min: 0,
            max: 1,
            radius: '80%',
            axisLine: {
                lineStyle: {       // 属性lineStyle控制线条样式  
                    color: [[0.86, '#2E5BFF'], [1, '#E0E7FF']],
                    width: 0
                },
            },
            axisLabel: {
              textStyle: {
                color: 'transparent'
              }
            },
            axisTick: {
              length:25,
              lineStyle: {
                color: 'auto'
              }
            },
            detail: {
              textStyle: {
                fontWeight: 'bold',
                color: '#000'
              }
            }
          }
          
        }
      }
      this.chartPieExtend = {
        title: [{
            text: '56.03%',
	        top:'45%',
	        left:'45%',
	        textStyle:{
	            color: '#000',
	            fontSize:18,
	        }
	      }],
        legend: {
          show: false
        },
        series: {
          radius: ['50%', '70%'],
          center: ['55%','45%'],
          color:['#FFB27C', '#E5E5E5']
        }
      }
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
      }
      return {
        chartData: {
          columns: ['type', 'value'],
          rows: [
            { type: '占比', value: 0.86 }
          ]
        },
        chartData2: {
          columns: ['名称', '报警次数'],
          rows: [
            { '名称': '本月', '报警次数': 1820 },
            { '名称': '上月', '报警次数': 1428 }
          ]
        }
      }
    },
    components: {
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
.mt20 { 
    margin-top 20px
}
.dot { 
    color #686868
    float right
    padding 3px 0
}
.data-all { 
    height: 230px;
    line-height: 230px;
    .num { 
        font-size: 48px;
        color: #2E384D;
        font-weight bold
    }
    .vertical-top { 
        vertical-align: top;
        color: #2E384D;
        font-size: 20px;
    }
}
.card-content {
    height 298px
    font-size 17px;
    color #B0BAC9;
}
.data-list li{ 
    line-height: 16px;
    text-align: left;
    letter-spacing: 0.68px;
    margin-bottom: 10px;
}
</style>
