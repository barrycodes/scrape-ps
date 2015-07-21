body > div.ng-scope > div.ng-scope > section.band > div.row:nth-child(2) > div.large-8 > div[ng-view]


course:

section#table-of-contents > div.row > div.small-12 > div.section-container


module & title                                                             > div.section > p.title > a.ng-binding


clip                                                                                     > div.content:nth-child() > ul > li > a[ng-click]

clip title															           > h5.ng-binding


time                                                                                                                         > div.action-icon-list > span.toc-time


$('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > p.title > a.ng-binding').click();

var z_title = $('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > div.content:nth-child(1) > ul > li > a[ng-click] > h5.ng-binding').text();
var z_time  = $('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > div.content:nth-child(1) > ul > li > div.action-icon-list > span.toc-time').text();
alert(z_title);
alert(z_time);

$('#table-of-contents > div.row > div.small-12 > div.section-container > div.section:nth-child(1) > div.content:nth-child(1) > ul > li > a[ng-click]').click();
